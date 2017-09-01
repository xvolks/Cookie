package com.ankamagames.dofus.datacenter.items.criterion
{
   import com.ankamagames.dofus.logic.game.common.managers.PlayedCharacterManager;
   import com.ankamagames.dofus.network.types.game.character.alignment.ActorExtendedAlignmentInformations;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class AlignmentLevelItemCriterion extends ItemCriterion implements IDataCenter
   {
       
      
      public function AlignmentLevelItemCriterion(param1:String)
      {
         super(param1);
      }
      
      override public function get text() : String
      {
         var _loc1_:String = I18n.getUiText("ui.tooltip.AlignmentLevel");
         return _loc1_ + " " + _operator.text + " " + _criterionValue;
      }
      
      override public function clone() : IItemCriterion
      {
         var _loc1_:AlignmentLevelItemCriterion = new AlignmentLevelItemCriterion(this.basicText);
         return _loc1_;
      }
      
      override protected function getCriterion() : int
      {
         var _loc1_:ActorExtendedAlignmentInformations = PlayedCharacterManager.getInstance().characteristics.alignmentInfos;
         return _loc1_.alignmentValue;
      }
   }
}
