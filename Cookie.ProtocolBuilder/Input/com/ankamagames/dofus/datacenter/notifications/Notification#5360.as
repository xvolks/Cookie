package com.ankamagames.dofus.datacenter.notifications
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   import com.ankamagames.jerakine.logger.Log;
   import com.ankamagames.jerakine.logger.Logger;
   import flash.utils.getQualifiedClassName;
   
   public class Notification#5360 implements IDataCenter
   {
      
      public static const MODULE:String = "Notifications";
      
      protected static const _log:Logger = Log.getLogger(getQualifiedClassName(Notification#5360));
       
      
      public var id:int;
      
      public var titleId:uint;
      
      public var messageId:uint;
      
      public var iconId:int;
      
      public var typeId:int;
      
      public var trigger:String;
      
      private var _title:String;
      
      private var _message:String;
      
      public function Notification#5360()
      {
         super();
      }
      
      public static function getNotificationById(param1:int) : Notification#5360
      {
         return GameData.getObject(MODULE,param1) as Notification#5360;
      }
      
      public static function getNotifications() : Array
      {
         return GameData.getObjects(MODULE);
      }
      
      public function get title() : String
      {
         if(!this._title)
         {
            this._title = I18n.getText(this.titleId);
         }
         return this._title;
      }
      
      public function get message() : String
      {
         if(!this._message)
         {
            this._message = I18n.getText(this.messageId);
         }
         return this._message;
      }
   }
}
