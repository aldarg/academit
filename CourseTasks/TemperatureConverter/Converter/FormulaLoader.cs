using System;
using System.IO;

namespace Academits.DargeevAleksandr
{
    internal class FormulaLoader
    {
        private string[][] formulas;

        internal FormulaLoader()
        {
            try
            {
                using (StreamReader reader = new StreamReader("formulas.txt"))
                {
                    string text = reader.ReadToEnd();

                    if (text.Length == 0)
                    {
                        throw new FileLoadException("Ошибка: пустой файл с формулами.");
                    }

                    string[] textSplitted = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    formulas = new string[textSplitted.Length][];

                    for (int i = 0; i < textSplitted.Length; ++i)
                    {
                        formulas[i] = textSplitted[i].Split(new char[] { ';' });
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("Ошибка: не найден файл с формулами.");
            }
            catch (FileLoadException )
            {
                throw;
            }
        }

        public string GetFormula(string input, string output)
        {
            foreach (string[] formula in formulas)
            {
                if (formula[0].Equals(input) && formula[1].Equals(output))
                {
                    return formula[2];
                }
            }

            throw new FileLoadException("Ошибка: не найдена нужная формула.");
        }
    }
}
