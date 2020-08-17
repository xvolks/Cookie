package com.ankamagames.dofus.datacenter.items.criterion
{
   import com.ankamagames.dofus.internalDatacenter.guild.GuildWrapper;
   import com.ankamagames.dofus.kernel.Kernel;
   import com.ankamagames.dofus.logic.game.common.frames.SocialFrame;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class GuildItemCriterion extends ItemCriterion implements IDataCenter
   {
       
      
      public function GuildItemCriterion(param1:String)
      {
         super(param1);
      }
      
      override public function get text() : String
      {
         if(_criterionValue == 0)
         {
            return I18n.getUiText("ui.criterion.noguild");
         }
         return I18n.getUiText("ui.criterion.hasGuild");
      }
      
      override public function clone() : IItemCriterion
      {
         var _loc1_:GuildItemCriterion = new GuildItemCriterion(this.basicText);
         return _loc1_;
      }
      
      override protected function getCriterion() : int
      {
         var _loc1_:GuildWrapper = (Kernel.getWorker().getFrame(SocialFrame) as SocialFrame).guild;
         if(_loc1_)
         {
            return 1;
         }
         return 0;
      }
   }
}
