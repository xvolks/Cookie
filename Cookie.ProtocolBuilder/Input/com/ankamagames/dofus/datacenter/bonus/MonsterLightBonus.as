package com.ankamagames.dofus.datacenter.bonus
{
   import com.ankamagames.dofus.datacenter.bonus.criterion.BonusAreaCriterion;
   import com.ankamagames.dofus.datacenter.bonus.criterion.BonusCriterion;
   import com.ankamagames.dofus.datacenter.bonus.criterion.BonusMonsterCriterion;
   import com.ankamagames.dofus.datacenter.bonus.criterion.BonusMonsterFamilyCriterion;
   import com.ankamagames.dofus.datacenter.bonus.criterion.BonusSubAreaCriterion;
   import com.ankamagames.dofus.logic.game.common.managers.PlayedCharacterManager;
   
   public class MonsterLightBonus extends Bonus
   {
       
      
      public function MonsterLightBonus()
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
            if(rest.length > 0 && _loc3_ is BonusMonsterCriterion && _loc3_.value == rest[0] || rest.length > 0 && _loc3_ is BonusMonsterFamilyCriterion && _loc3_.value == rest[0] || _loc3_ is BonusAreaCriterion && _loc3_.value == PlayedCharacterManager.getInstance().currentSubArea.areaId || _loc3_ is BonusSubAreaCriterion && _loc3_.value == PlayedCharacterManager.getInstance().currentSubArea.id)
            {
               return true;
            }
         }
         return false;
      }
   }
}
