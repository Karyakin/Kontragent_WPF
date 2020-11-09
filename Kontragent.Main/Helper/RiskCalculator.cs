using Kontragent.RiskInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Kontragent.Helper
{
    public static class RiskCalculator
    {
        public static int Value => Risks.Sum(x => x.Risk);//свойство возвращает сумму всех рисков, находящихся в списке
        public static int LastValue { get; private set; }
        public static List<IRiskParametr> Risks { get; private set; } = new List<IRiskParametr>();

        /// <summary>
        /// Это событие, оно вызывается, когда калькулятор начинает считать риски и каждый раз будет обновлять прогрессбар
        /// чтобы не вешать на каждый чекбокс отдельное событие на изменения
        /// </summary>
        public static event EventHandler ValueChanged;


        /// <summary>
        /// Если в метод приходит значение Value true, то мы добавляем в негатив значение Risk
        /// Если в метод приходит значение Value false, то мы минусуем из негатива значение Risk
        /// </summary>
        /// <param name="Note"></param>
        public static void Note(INegativeRiskCheckBoxParametr risk) //создали экземпляр интерфейса и теперь имеем доспуп к свойствам Value и Risk 
        {
            if (risk.Value == true)
            {
                AddRisk(risk);
            }
            else
            {
                RemoveRisk(risk);
            }
        }

        /// <summary>
        /// Если в метод приходит значение Value true, то мы минусуем из негатив значение Risk
        /// Если в метод приходит значение Value false, то мы добавляем в негатива значение Risk
        /// </summary>
        /// <param name="Note"></param>
        public static void Note(IPositiveRiskCheckBoxParametr risk)
        {
            if (risk.Value == true)
            {
                RemoveRisk(risk);
            }
            else
            {
                AddRisk(risk);
            }
        }



        public static void Note(IRiskParametr risk, IRiskParametr removingParameter = null)
        {
            if (risk == null && removingParameter == null)
            {
                return;
            }
            if (risk == null)
            {
                RemoveRisk(removingParameter);
                return;
            }

            if (removingParameter != null && Risks.Contains(removingParameter))
                RemoveRisk(removingParameter);

            AddRisk(risk);

        }


        public static void Note(IRiskCreatedDateParametr risk)
        {
            if (risk == null)
                return;

            if ((DateTime.Now - risk.Value).Days < 365)
            {
                if (Risks.Contains(risk))
                    RemoveRisk(risk);

                AddRisk(risk);
            }
            else
            {
                RemoveRisk(risk);// удаляем предыдущее значение 
            }


        }

        private static void AddRisk(IRiskParametr risk)
        {
            Risks.Add(risk);
            ValueChanged?.Invoke(null, new EventArgs());
            //MessageBox.Show(Value.ToString());
        }

        public static void RemoveRisk(IRiskParametr risk)
        {
            Risks.Remove(risk);
            ValueChanged?.Invoke(null, new EventArgs());
        }
    }
}
