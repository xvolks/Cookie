package com.ankamagames.dofus.datacenter.items.criterion
{
   import com.ankamagames.dofus.datacenter.mounts.MountFamily;
   import com.ankamagames.dofus.internalDatacenter.mount.MountData;
   import com.ankamagames.dofus.logic.game.common.managers.PlayedCharacterManager;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class MountFamilyItemCriterion extends ItemCriterion implements IDataCenter
   {
       
      
      public function MountFamilyItemCriterion(param1:String)
      {
         super(param1);
      }
      
      override public function get text() : String
      {
         var _loc2_:String = null;
         var _loc1_:MountFamily = MountFamily.getMountFamilyById(Number(_criterionValue));
         if(!_loc1_)
         {
            _loc2_ = "???";
         }
         else
         {
            _loc2_ = _loc1_.name;
         }
         if(_operator.text == ItemCriterionOperator.EQUAL)
         {
            return I18n.getUiText("ui.tooltip.mountEquipedFamily",[_loc2_]);
         }
         if(_operator.text == ItemCriterionOperator.DIFFERENT)
         {
            return I18n.getUiText("ui.tooltip.mountNonEquipedFamily",[_loc2_]);
         }
         return "";
      }
      
      override public function clone() : IItemCriterion
      {
         var _loc1_:MountFamilyItemCriterion = new MountFamilyItemCriterion(this.basicText);
         return _loc1_;
      }
      
      override protected function getCriterion() : int
      {
         var _loc1_:MountData = PlayedCharacterManager.getInstance().mount;
         if(!_loc1_ || !PlayedCharacterManager.getInstance().isRidding)
         {
            return -1;
         }
         return _loc1_.model.familyId;
      }
   }
}
