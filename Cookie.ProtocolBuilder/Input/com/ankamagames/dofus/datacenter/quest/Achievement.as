package com.ankamagames.dofus.datacenter.quest
{
   import com.ankamagames.dofus.datacenter.items.criterion.LevelItemCriterion;
   import com.ankamagames.dofus.datacenter.items.criterion.PrestigeLevelItemCriterion;
   import com.ankamagames.dofus.logic.game.roleplay.managers.RoleplayManager;
   import com.ankamagames.dofus.misc.utils.GameDataQuery;
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   import com.ankamagames.jerakine.logger.Log;
   import com.ankamagames.jerakine.logger.Logger;
   import flash.utils.getQualifiedClassName;
   
   public class Achievement implements IDataCenter
   {
      
      protected static const _log:Logger = Log.getLogger(getQualifiedClassName(Achievement));
      
      public static const MODULE:String = "Achievements";
       
      
      public var id:uint;
      
      public var nameId:uint;
      
      public var categoryId:uint;
      
      public var descriptionId:uint;
      
      public var iconId:uint;
      
      public var points:uint;
      
      public var level:uint;
      
      public var order:uint;
      
      public var kamasRatio:Number;
      
      public var experienceRatio:Number;
      
      public var kamasScaleWithPlayerLevel:Boolean;
      
      public var objectiveIds:Vector.<int>;
      
      public var rewardIds:Vector.<int>;
      
      private var _name:String;
      
      private var _desc:String;
      
      private var _category:AchievementCategory;
      
      public function Achievement()
      {
         super();
      }
      
      public static function getAchievementById(param1:int) : Achievement
      {
         return GameData.getObject(MODULE,param1) as Achievement;
      }
      
      public static function getAchievements() : Array
      {
         return GameData.getObjects(MODULE);
      }
      
      public function get name() : String
      {
         if(!this._name)
         {
            this._name = I18n.getText(this.nameId);
         }
         return this._name;
      }
      
      public function get description() : String
      {
         if(!this._desc)
         {
            this._desc = I18n.getText(this.descriptionId);
         }
         return this._desc;
      }
      
      public function get category() : AchievementCategory
      {
         if(!this._category)
         {
            this._category = AchievementCategory.getAchievementCategoryById(this.categoryId);
         }
         return this._category;
      }
      
      public function get canBeStarted() : Boolean
      {
         var _loc1_:Achievement = null;
         var _loc2_:int = 0;
         var _loc3_:AchievementObjective = null;
         var _loc4_:Array = null;
         var _loc5_:Quest = null;
         var _loc6_:QuestObjective = null;
         var _loc7_:Vector.<uint> = null;
         for each(_loc2_ in this.objectiveIds)
         {
            _loc3_ = AchievementObjective.getAchievementObjectiveById(_loc2_);
            if(_loc3_)
            {
               _loc4_ = _loc3_.criterion.substr(3).split(",");
               if(_loc3_.criterion.indexOf("PL") == 0)
               {
                  return new LevelItemCriterion(_loc3_.criterion).isRespected;
               }
               if(_loc3_.criterion.indexOf("Pl") == 0)
               {
                  return new PrestigeLevelItemCriterion(_loc3_.criterion).isRespected;
               }
               if(_loc3_.criterion.indexOf("OA") == 0)
               {
                  _loc1_ = getAchievementById(parseInt(_loc4_[0]));
                  if(!_loc1_.canBeStarted)
                  {
                     return false;
                  }
               }
               else if(_loc3_.criterion.indexOf("Q") == 0)
               {
                  if(_loc3_.criterion.charAt(1) == "o")
                  {
                     _loc6_ = QuestObjective.getQuestObjectiveById(parseInt(_loc4_[0]));
                     _loc7_ = GameDataQuery.queryEquals(Quest,"stepIds",_loc6_.stepId);
                     if(_loc7_.length > 0)
                     {
                        _loc5_ = Quest.getQuestById(_loc7_[0]);
                     }
                  }
                  else
                  {
                     _loc5_ = Quest.getQuestById(parseInt(_loc4_[0]));
                  }
                  if(!_loc5_ || !_loc5_.canBeStarted)
                  {
                     return false;
                  }
               }
            }
         }
         return true;
      }
      
      public function getKamasReward(param1:int) : Number
      {
         return RoleplayManager.getInstance().getKamasReward(this.kamasScaleWithPlayerLevel,this.level,this.kamasRatio,1,param1);
      }
      
      public function getExperienceReward(param1:int, param2:int) : Number
      {
         return RoleplayManager.getInstance().getExperienceReward(param1,param2,this.level,this.experienceRatio);
      }
   }
}
