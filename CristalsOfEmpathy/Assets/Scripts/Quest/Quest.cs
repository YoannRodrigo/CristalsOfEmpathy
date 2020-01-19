#region Using Directives

using UnityEngine;

#endregion

namespace Assets.Scripts.Quest
{
    //DEFINING A QUEST
    //DO NOT DELETE ! MAY BE USED LATER FOR QUEST MANAGEMENT IMPROVEMENT
    public class Quest : MonoBehaviour
    {
        #region Properties

        public int Id { get; set; }

        public string QuestName { get; set; }

        public string QuestGiver { get; set; }

        public string QuestObjective { get; set; }

        #endregion

        #region Constructor

        public Quest(int id, string questName, string questGiver, string questObjective)
        {
            Id = id;
            QuestName = questName;
            QuestGiver = questGiver;
            QuestObjective = questObjective;
        }

        public Quest(int id, string questName, string questGiver)
        {
            Id = id;
            QuestName = questName;
            QuestGiver = questGiver;
        }

        public Quest(int id, string questName)
        {
            Id = id;
            QuestName = questName;
        }

        #endregion
    }
}