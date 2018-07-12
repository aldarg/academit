using System;
using System.Data;

namespace Academits.DargeevAleksandr
{
    internal class Converter
    {
        private double inputValue;
        private string inputType;
        private string outputType;

        internal Converter(double inputValue, string inputType, string outputType)
        {
            this.inputValue = inputValue;

            if (inputType.IndexOf("from") == -1 || outputType.IndexOf("to") == -1)
            {
                throw new ArgumentException("Некорректное название переключателя входной или выходной шкалы температур.");
            }

            this.inputType = inputType.Replace("from", "").ToLower();
            this.outputType = outputType.Replace("to", "").ToLower();
        }

        internal double GetResult()
        {
            if (inputType == outputType)
            {
                return inputValue;
            }

            double result;

            try
            {
                FormulaLoader loader = new FormulaLoader();
                string formula = loader.GetFormula(inputType, outputType).Replace("input", inputValue.ToString());

                result = Convert.ToDouble(new DataTable().Compute(formula, null));
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}
