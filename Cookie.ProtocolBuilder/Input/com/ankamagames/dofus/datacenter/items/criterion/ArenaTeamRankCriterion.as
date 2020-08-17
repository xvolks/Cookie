package com.ankamagames.dofus.datacenter.items.criterion
{
   import com.ankamagames.dofus.kernel.Kernel;
   import com.ankamagames.dofus.logic.game.common.frames.PartyManagementFrame;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class ArenaTeamRankCriterion extends ItemCriterion implements IDataCenter
   {
       
      
      public function ArenaTeamRankCriterion(param1:String)
      {
         super(param1);
      }
      
      override public function get text() : String
      {
         var _loc1_:String = String(_criterionValue);
         var _loc2_:String = I18n.getUiText("ui.common.pvpTeamRank");
         var _loc3_:* = ">";
         if(_operator.text == ItemCriterionOperator.DIFFERENT)
         {
            _loc3_ = I18n.getUiText("ui.common.differentFrom") + " >";
         }
         return _loc2_ + " " + _loc3_ + " " + _loc1_;
      }
      
      override public function clone() : IItemCriterion
      {
         var _loc1_:ArenaTeamRankCriterion = new ArenaTeamRankCriterion(this.basicText);
         return _loc1_;
      }
      
      override protected function getCriterion() : int
      {
         var _loc1_:PartyManagementFrame = Kernel.getWorker().getFrame(PartyManagementFrame) as PartyManagementFrame;
         var _loc2_:int = 0;
         if(_loc1_.arenaRankGroupInfos && _loc1_.arenaRankGroupInfos.rank > _loc2_)
         {
            _loc2_ = _loc1_.arenaRankGroupInfos.rank;
         }
         return _loc2_;
      }
   }
}
