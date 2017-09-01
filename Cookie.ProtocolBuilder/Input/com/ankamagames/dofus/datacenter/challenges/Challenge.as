package com.ankamagames.dofus.datacenter.challenges
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   import com.ankamagames.jerakine.logger.Log;
   import com.ankamagames.jerakine.logger.Logger;
   import flash.utils.getQualifiedClassName;
   
   public class Challenge implements IDataCenter
   {
      
      public static const MODULE:String = "Challenge";
      
      protected static const _log:Logger = Log.getLogger(getQualifiedClassName(Challenge));
       
      
      public var id:int;
      
      public var nameId:uint;
      
      public var descriptionId:uint;
      
      public var dareAvailable:Boolean;
      
      public var incompatibleChallenges:Vector.<uint>;
      
      private var _name:String;
      
      private var _description:String;
      
      public function Challenge()
      {
         super();
      }
      
      public static function getChallengeById(param1:int) : Challenge
      {
         return GameData.getObject(MODULE,param1) as Challenge;
      }
      
      public static function getChallenges() : Array
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
         if(!this._description)
         {
            this._description = I18n.getText(this.descriptionId);
         }
         return this._description;
      }
   }
}
