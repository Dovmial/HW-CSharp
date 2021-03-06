using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMailerForm.NewsContentModel
{
    public class NewsPolitic : INewsContent, IEnumerable
    {
        public List<string> News { get; private set; }
        public NewsPolitic()
        {
            NewsLoad();
        }
        public void NewsLoad()
        {
            News = new List<string>()
           {
                @"Guardian: Индия отменила визит британской делегации из-за разногласий по Украине
Индия отменила визит британской делегации на фоне ситуации на Украине, пишет The Guardian.
РИА Новости
Владимир Путин 21 февраля в ответ на просьбы республик Донбасса и после обращения депутатов Госдумы подписал указы о признании суверенитета ЛНР и ДНР.
РИА Новости
По заявлению Минобороны, вооруженные силы наносят удары только по военной инфраструктуре и украинским войскам.
РИА Новости
После начала военной операции по демилитаризации Украины Запад одобрил ряд новых санкций против России, а в Европе все громче заговорили о необходимости снижения зависимости от российских энергоресурсов.",
                @"Французы в соцсетях отказались поддержать Зеленского, выступившего перед парламентом
Французы в социальных сетях выступили против антироссийского выступления Зеленского.
РИА Новости
Французские пользователи предположили, что опасная риторика Зеленского обернется для Европы печальными последствиями.
РИА Новости
'Сегодня очень хорошо видно, что Зеленский оказался безответственным безумцем и может привести нас к смертельному противостоянию', — заключил француз.
РИА Новости",

                @"FP: в США призывают наказать Саудовскую Аравию за поддержку России
Авторы издания Foreign Policy заявили, что президент США Джо Байден должен воспользоваться ситуацией и пересмотреть отношения с Саудовской Аравией.
NVL
По мнению автора статьи, президент США Джо Байден должен переосмыслить отношения Вашингтона с Эр-Риядом, прекратить любые поставки оружия и разорвать контракты на ремонт и обслуживание саудовской боевой техники.
Газета.Ru
Как утверждает журнал, после 'арабской весны' Саудовская Аравия начала укреплять отношения как с Россией, так и с Китаем.
РИА Новости
Страны Запада после начала военной спецоперации по демилитаризации Украины утвердили серию новых санкций против России, а в Европе громче стали звучать заявления о необходимости снизить зависимость от российских энергоресурсов."
           };
        }
    }
}
