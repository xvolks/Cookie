package com.ankamagames.dofus.datacenter.misc
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class Tips implements IDataCenter
   {
      
      public static const MODULE:String = "Tips";
       
      
      public var id:int;
      
      public var descId:uint;
      
      private var _description:String;
      
      public function Tips()
      {
         super();
      }
      
      public static function getTipsById(param1:int) : Tips
      {
         return GameData.getObject(MODULE,param1) as Tips;
      }
      
      public static function getAllTips() : Array
      {
         return GameData.getObjects(MODULE);
      }
      
      public function get description() : String
      {
         if(!this._description)
         {
            this._description = I18n.getText(this.descId);
         }
         return this._description;
      }
   }
}
