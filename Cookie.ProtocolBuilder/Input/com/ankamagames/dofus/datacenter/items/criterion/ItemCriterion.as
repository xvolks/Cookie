package com.ankamagames.dofus.datacenter.items.criterion
{
   import com.ankamagames.dofus.logic.game.common.managers.PlayedCharacterManager;
   import com.ankamagames.dofus.network.types.game.character.characteristic.CharacterBaseCharacteristic;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   import com.ankamagames.jerakine.logger.Log;
   import com.ankamagames.jerakine.logger.Logger;
   import flash.utils.getQualifiedClassName;
   
   public class ItemCriterion implements IItemCriterion, IDataCenter
   {
      
      protected static const _log:Logger = Log.getLogger(getQualifiedClassName(ItemCriterion));
       
      
      protected var _serverCriterionForm:String;
      
      protected var _operator:ItemCriterionOperator;
      
      protected var _criterionRef:String;
      
      protected var _criterionValue:int;
      
      protected var _criterionValueText:String;
      
      public function ItemCriterion(param1:String)
      {
         super();
         this._serverCriterionForm = param1;
         this.getInfos();
      }
      
      public function get inlineCriteria() : Vector.<IItemCriterion>
      {
         var _loc1_:Vector.<IItemCriterion> = new Vector.<IItemCriterion>();
         _loc1_.push(this);
         return _loc1_;
      }
      
      public function get criterionValue() : Object
      {
         return this._criterionValue;
      }
      
      public function get operator() : String
      {
         return !!this._operator?this._operator.text:null;
      }
      
      public function get isRespected() : Boolean
      {
         var _loc1_:PlayedCharacterManager = PlayedCharacterManager.getInstance();
         if(!_loc1_ || !_loc1_.characteristics)
         {
            return true;
         }
         return this._operator.compare(this.getCriterion(),this._criterionValue);
      }
      
      public function get text() : String
      {
         return this.buildText(false);
      }
      
      public function get textForTooltip() : String
      {
         return this.buildText(true);
      }
      
      public function get basicText() : String
      {
         return this._serverCriterionForm;
      }
      
      public function clone() : IItemCriterion
      {
         var _loc1_:IItemCriterion = new ItemCriterion(this.basicText);
         return _loc1_;
      }
      
      private function buildText(param1:Boolean = false) : String
      {
         var _loc2_:String = null;
         var _loc3_:Array = null;
         var _loc4_:int = 0;
         switch(this._criterionRef)
         {
            case "CM":
               _loc2_ = I18n.getUiText("ui.stats.movementPoints");
               break;
            case "CP":
               _loc2_ = I18n.getUiText("ui.stats.actionPoints");
               break;
            case "CH":
               _loc2_ = I18n.getUiText("ui.pvp.honourPoints");
               break;
            case "CD":
               _loc2_ = I18n.getUiText("ui.pvp.disgracePoints");
               break;
            case "CT":
               _loc2_ = I18n.getUiText("ui.stats.takleBlock");
               break;
            case "Ct":
               _loc2_ = I18n.getUiText("ui.stats.takleEvade");
               break;
            default:
               _loc3_ = ["CS","Cs","CV","Cv","CA","Ca","CI","Ci","CW","Cw","CC","Cc","PG","PJ","Pj","PM","PA","PN","PE","<NO>","PS","PR","PL","PK","Pg","Pr","Ps","Pa","PP","PZ","CM","Qa","CP","ca","cc","ci","cs","cv","cw","Pl"];
               _loc4_ = _loc3_.indexOf(this._criterionRef);
               if(_loc4_ > -1)
               {
                  _loc2_ = I18n.getUiText("ui.item.characteristics").split(",")[_loc4_];
                  break;
               }
               _log.warn("Unknown criteria \'" + this._criterionRef + "\'");
               break;
         }
         if(param1)
         {
            return _loc4_ > -1?_loc2_ + " " + "<span class=\'#valueCssClass\'>" + this._operator.text + " " + this._criterionValue + "</span>":null;
         }
         return _loc2_ + " " + this._operator.text + " " + this._criterionValue;
      }
      
      protected function getInfos() : void
      {
         var _loc1_:String = null;
         for each(_loc1_ in ItemCriterionOperator.OPERATORS_LIST)
         {
            if(this._serverCriterionForm.indexOf(_loc1_) == 2)
            {
               this._operator = new ItemCriterionOperator(_loc1_);
               this._criterionRef = this._serverCriterionForm.split(_loc1_)[0];
               this._criterionValue = this._serverCriterionForm.split(_loc1_)[1];
               this._criterionValueText = this._serverCriterionForm.split(_loc1_)[1];
            }
         }
      }
      
      protected function getCriterion() : int
      {
         var _loc1_:int = 0;
         var _loc2_:PlayedCharacterManager = PlayedCharacterManager.getInstance();
         switch(this._criterionRef)
         {
            case "Ca":
               _loc1_ = _loc2_.characteristics.agility.base;
               break;
            case "CA":
               _loc1_ = this.getTotalCharac(_loc2_.characteristics.agility);
               break;
            case "Cc":
               _loc1_ = _loc2_.characteristics.chance.base;
               break;
            case "CC":
               _loc1_ = this.getTotalCharac(_loc2_.characteristics.chance);
               break;
            case "Ce":
               _loc1_ = _loc2_.characteristics.energyPoints;
               break;
            case "CE":
               _loc1_ = _loc2_.characteristics.maxEnergyPoints;
               break;
            case "CH":
               _loc1_ = _loc2_.characteristics.alignmentInfos.honor;
               break;
            case "Ci":
               _loc1_ = _loc2_.characteristics.intelligence.base;
               break;
            case "CI":
               _loc1_ = this.getTotalCharac(_loc2_.characteristics.intelligence);
               break;
            case "CL":
               _loc1_ = _loc2_.characteristics.lifePoints;
               break;
            case "CM":
               _loc1_ = this.getTotalCharac(_loc2_.characteristics.movementPoints);
               break;
            case "CP":
               _loc1_ = this.getTotalCharac(_loc2_.characteristics.actionPoints);
               break;
            case "Cs":
               _loc1_ = _loc2_.characteristics.strength.base;
               break;
            case "CS":
               _loc1_ = this.getTotalCharac(_loc2_.characteristics.strength);
               break;
            case "Cv":
               _loc1_ = _loc2_.characteristics.vitality.base;
               break;
            case "CV":
               _loc1_ = this.getTotalCharac(_loc2_.characteristics.vitality);
               break;
            case "Cw":
               _loc1_ = _loc2_.characteristics.wisdom.base;
               break;
            case "CW":
               _loc1_ = this.getTotalCharac(_loc2_.characteristics.wisdom);
               break;
            case "Ct":
               _loc1_ = this.getTotalCharac(_loc2_.characteristics.tackleEvade);
               break;
            case "CT":
               _loc1_ = this.getTotalCharac(_loc2_.characteristics.tackleBlock);
               break;
            case "ca":
               _loc1_ = _loc2_.characteristics.agility.additionnal;
               break;
            case "cc":
               _loc1_ = _loc2_.characteristics.chance.additionnal;
               break;
            case "ci":
               _loc1_ = _loc2_.characteristics.intelligence.additionnal;
               break;
            case "cs":
               _loc1_ = _loc2_.characteristics.strength.additionnal;
               break;
            case "cv":
               _loc1_ = _loc2_.characteristics.vitality.additionnal;
               break;
            case "cw":
               _loc1_ = _loc2_.characteristics.wisdom.additionnal;
         }
         return _loc1_;
      }
      
      private function getTotalCharac(param1:CharacterBaseCharacteristic) : int
      {
         return param1.base + param1.additionnal + param1.alignGiftBonus + param1.contextModif + param1.objectsAndMountBonus;
      }
   }
}
