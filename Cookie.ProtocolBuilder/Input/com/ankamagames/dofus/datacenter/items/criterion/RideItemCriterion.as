package com.ankamagames.dofus.datacenter.items.criterion
{
   import com.ankamagames.dofus.datacenter.mounts.Mount;
   import com.ankamagames.dofus.internalDatacenter.mount.MountData;
   import com.ankamagames.dofus.logic.game.common.managers.PlayedCharacterManager;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class RideItemCriterion extends ItemCriterion implements IDataCenter
   {
       
      
      public function RideItemCriterion(param1:String)
      {
         super(param1);
      }
      
      override public function get text() : String
      {
         var _loc1_:String = null;
         var _loc2_:Mount = Mount.getMountById(_criterionValue);
         if(_criterionValue == 0 || !_loc2_)
         {
            return "";
         }
         if(_operator.text == ItemCriterionOperator.EQUAL)
         {
            _loc1_ = I18n.getUiText("ui.tooltip.mountEquiped",[_loc2_.name]);
         }
         else if(_operator.text == ItemCriterionOperator.DIFFERENT)
         {
            _loc1_ = I18n.getUiText("ui.tooltip.mountNonEquiped",[_loc2_.name]);
         }
         return _loc1_;
      }
      
      override public function clone() : IItemCriterion
      {
         var _loc1_:RideItemCriterion = new RideItemCriterion(this.basicText);
         return _loc1_;
      }
      
      override protected function getCriterion() : int
      {
         var _loc1_:int = 0;
         var _loc2_:MountData = PlayedCharacterManager.getInstance().mount;
         if(_loc2_ && PlayedCharacterManager.getInstance().isRidding)
         {
            _loc1_ = _loc2_.modelId;
         }
         return _loc1_;
      }
   }
}
