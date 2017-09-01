package com.ankamagames.dofus.datacenter.items.criterion
{
   import com.ankamagames.dofus.kernel.Kernel;
   import com.ankamagames.dofus.logic.game.common.frames.PartyManagementFrame;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class ArenaMaxSoloRankCriterion extends ItemCriterion implements IDataCenter
   {
       
      
      public function ArenaMaxSoloRankCriterion(param1:String)
      {
         super(param1);
      }
      
      override public function get text() : String
      {
         var _loc1_:String = String(_criterionValue);
         var _loc2_:String = I18n.getUiText("ui.common.pvpMaxSoloRank");
         var _loc3_:* = ">";
         if(_operator.text == ItemCriterionOperator.DIFFERENT)
         {
            _loc3_ = I18n.getUiText("ui.common.differentFrom") + " >";
         }
         return _loc2_ + " " + _loc3_ + " " + _loc1_;
      }
      
      override public function clone() : IItemCriterion
      {
         var _loc1_:ArenaMaxSoloRankCriterion = new ArenaMaxSoloRankCriterion(this.basicText);
         return _loc1_;
      }
      
      override protected function getCriterion() : int
      {
         var _loc1_:PartyManagementFrame = Kernel.getWorker().getFrame(PartyManagementFrame) as PartyManagementFrame;
         var _loc2_:int = _loc1_.arenaRankSoloInfos.maxRank;
         return _loc2_;
      }
   }
}
