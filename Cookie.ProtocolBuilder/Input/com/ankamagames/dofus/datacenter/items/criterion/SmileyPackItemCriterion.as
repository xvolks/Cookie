package com.ankamagames.dofus.datacenter.items.criterion
{
   import com.ankamagames.dofus.datacenter.communication.SmileyPack;
   import com.ankamagames.dofus.kernel.Kernel;
   import com.ankamagames.dofus.logic.game.common.frames.ChatFrame;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class SmileyPackItemCriterion extends ItemCriterion implements IDataCenter
   {
       
      
      public function SmileyPackItemCriterion(param1:String)
      {
         super(param1);
      }
      
      override public function get isRespected() : Boolean
      {
         var _loc2_:SmileyPack = null;
         var _loc1_:Array = (Kernel.getWorker().getFrame(ChatFrame) as ChatFrame).smileyPacks;
         for each(_loc2_ in _loc1_)
         {
            if(_loc2_.id == _criterionValue)
            {
               return false;
            }
         }
         return true;
      }
      
      override public function get text() : String
      {
         var _loc1_:String = null;
         if(_operator.text == ItemCriterionOperator.DIFFERENT)
         {
            _loc1_ = I18n.getUiText("ui.tooltip.dontPossessSmileyPack");
         }
         else
         {
            _loc1_ = I18n.getUiText("ui.tooltip.possessSmileyPack");
         }
         return _loc1_ + " \'" + SmileyPack.getSmileyPackById(_criterionValue).name + "\'";
      }
      
      override public function clone() : IItemCriterion
      {
         var _loc1_:SmileyPackItemCriterion = new SmileyPackItemCriterion(this.basicText);
         return _loc1_;
      }
      
      override protected function getCriterion() : int
      {
         var _loc2_:SmileyPack = null;
         var _loc1_:Array = (Kernel.getWorker().getFrame(ChatFrame) as ChatFrame).smileyPacks;
         for each(_loc2_ in _loc1_)
         {
            if(_loc2_.id == _criterionValue)
            {
               return 1;
            }
         }
         return 0;
      }
   }
}
