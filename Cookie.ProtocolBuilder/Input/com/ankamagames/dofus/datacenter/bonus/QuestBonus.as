package com.ankamagames.dofus.datacenter.bonus
{
   import com.ankamagames.dofus.datacenter.bonus.criterion.BonusCriterion;
   import com.ankamagames.dofus.datacenter.bonus.criterion.BonusQuestCategoryCriterion;
   
   public class QuestBonus extends Bonus
   {
       
      
      public function QuestBonus()
      {
         super();
      }
      
      override public function isRespected(... rest) : Boolean
      {
         var _loc2_:int = 0;
         var _loc3_:BonusCriterion = null;
         for each(_loc2_ in criterionsIds)
         {
            _loc3_ = BonusCriterion.getBonusCriterionById(_loc2_);
            if(rest.length > 0 && _loc3_ is BonusQuestCategoryCriterion && _loc3_.value == rest[0])
            {
               return true;
            }
         }
         return false;
      }
   }
}
