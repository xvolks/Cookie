package com.ankamagames.dofus.datacenter.items.criterion
{
   import com.ankamagames.dofus.datacenter.alignments.AlignmentRank;
   import com.ankamagames.dofus.logic.game.common.frames.AlignmentFrame;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class SpecializationItemCriterion extends ItemCriterion implements IDataCenter
   {
       
      
      public function SpecializationItemCriterion(param1:String)
      {
         super(param1);
      }
      
      override public function get text() : String
      {
         var _loc1_:String = AlignmentRank.getAlignmentRankById(int(_criterionValue)).name;
         var _loc2_:String = I18n.getUiText("ui.alignment.spécialization");
         var _loc3_:String = I18n.getUiText("ui.common.colon");
         if(_operator.text == ItemCriterionOperator.DIFFERENT)
         {
            _loc3_ = " " + I18n.getUiText("ui.common.differentFrom") + I18n.getUiText("ui.common.colon");
         }
         return _loc2_ + _loc3_ + _loc1_;
      }
      
      override public function clone() : IItemCriterion
      {
         var _loc1_:SpecializationItemCriterion = new SpecializationItemCriterion(this.basicText);
         return _loc1_;
      }
      
      override protected function getCriterion() : int
      {
         return AlignmentFrame.getInstance().playerRank;
      }
   }
}
