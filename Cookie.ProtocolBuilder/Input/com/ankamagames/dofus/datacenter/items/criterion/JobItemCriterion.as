package com.ankamagames.dofus.datacenter.items.criterion
{
   import com.ankamagames.dofus.datacenter.jobs.Job;
   import com.ankamagames.dofus.internalDatacenter.jobs.KnownJobWrapper;
   import com.ankamagames.dofus.logic.game.common.managers.PlayedCharacterManager;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class JobItemCriterion extends ItemCriterion implements IDataCenter
   {
       
      
      private var _jobId:uint;
      
      private var _jobLevel:int = -1;
      
      public function JobItemCriterion(param1:String)
      {
         super(param1);
         var _loc2_:Array = String(_criterionValueText).split(",");
         if(_loc2_ && _loc2_.length > 0)
         {
            if(_loc2_.length <= 2)
            {
               this._jobId = uint(_loc2_[0]);
               this._jobLevel = int(_loc2_[1]);
            }
         }
         else
         {
            this._jobId = uint(_criterionValue);
            this._jobLevel = -1;
         }
      }
      
      override public function get isRespected() : Boolean
      {
         var _loc1_:KnownJobWrapper = PlayedCharacterManager.getInstance().jobs[this._jobId];
         if(!_loc1_)
         {
            return false;
         }
         if(this._jobLevel == -1)
         {
            return true;
         }
         if(_loc1_.jobLevel > this._jobLevel)
         {
            return true;
         }
         return false;
      }
      
      override public function get text() : String
      {
         var _loc1_:String = "";
         var _loc2_:String = "";
         var _loc3_:Job = Job.getJobById(this._jobId);
         if(!_loc3_)
         {
            return _loc2_;
         }
         var _loc4_:String = _loc3_.name;
         var _loc5_:String = "";
         if(this._jobLevel >= 0)
         {
            _loc5_ = " " + I18n.getUiText("ui.common.short.level") + " " + String(this._jobLevel);
         }
         switch(_operator.text)
         {
            case ItemCriterionOperator.EQUAL:
               _loc2_ = _loc4_ + _loc5_;
               break;
            case ItemCriterionOperator.DIFFERENT:
               _loc2_ = I18n.getUiText("ui.common.dontBe") + _loc4_ + _loc5_;
               break;
            case ItemCriterionOperator.SUPERIOR:
               _loc1_ = " >";
               _loc2_ = _loc4_ + _loc1_ + _loc5_;
               break;
            case ItemCriterionOperator.INFERIOR:
               _loc1_ = " <";
               _loc2_ = _loc4_ + _loc1_ + _loc5_;
         }
         return _loc2_;
      }
      
      override public function clone() : IItemCriterion
      {
         var _loc1_:JobItemCriterion = new JobItemCriterion(this.basicText);
         return _loc1_;
      }
   }
}
