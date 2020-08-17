package com.ankamagames.dofus.datacenter.quest
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   import com.ankamagames.jerakine.logger.Log;
   import com.ankamagames.jerakine.logger.Logger;
   import flash.utils.getQualifiedClassName;
   
   public class AchievementObjective implements IDataCenter
   {
      
      protected static const _log:Logger = Log.getLogger(getQualifiedClassName(AchievementObjective));
      
      public static const MODULE:String = "AchievementObjectives";
       
      
      public var id:uint;
      
      public var achievementId:uint;
      
      public var order:uint;
      
      public var nameId:uint;
      
      public var criterion:String;
      
      private var _name:String;
      
      public function AchievementObjective()
      {
         super();
      }
      
      public static function getAchievementObjectiveById(param1:int) : AchievementObjective
      {
         return GameData.getObject(MODULE,param1) as AchievementObjective;
      }
      
      public static function getAchievementObjectives() : Array
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
   }
}
