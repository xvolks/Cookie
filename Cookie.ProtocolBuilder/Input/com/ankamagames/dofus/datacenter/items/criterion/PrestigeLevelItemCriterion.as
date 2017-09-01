package com.ankamagames.dofus.datacenter.items.criterion
{
   import com.ankamagames.dofus.logic.game.common.managers.PlayedCharacterManager;
   import com.ankamagames.dofus.network.ProtocolConstantsEnum;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class PrestigeLevelItemCriterion extends ItemCriterion implements IDataCenter
   {
       
      
      public function PrestigeLevelItemCriterion(param1:String)
      {
         super(param1);
      }
      
      override public function get text() : String
      {
         var _loc1_:String = _criterionValue.toString();
         var _loc2_:String = I18n.getUiText("ui.common.prestige");
         return _loc2_ + " " + _operator.text + " " + _loc1_;
      }
      
      override public function clone() : IItemCriterion
      {
         var _loc1_:PrestigeLevelItemCriterion = new PrestigeLevelItemCriterion(this.basicText);
         return _loc1_;
      }
      
      override protected function getCriterion() : int
      {
         var _loc1_:int = 0;
         if(PlayedCharacterManager.getInstance().infos.level > ProtocolConstantsEnum.MAX_LEVEL)
         {
            _loc1_ = PlayedCharacterManager.getInstance().infos.level - ProtocolConstantsEnum.MAX_LEVEL;
         }
         return _loc1_;
      }
   }
}
