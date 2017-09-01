package com.ankamagames.dofus.datacenter.mounts
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class Mount implements IDataCenter
   {
      
      private static var MODULE:String = "Mounts";
       
      
      public var id:uint;
      
      public var familyId:uint;
      
      public var nameId:uint;
      
      public var look:String;
      
      private var _name:String;
      
      public function Mount()
      {
         super();
      }
      
      public static function getMountById(param1:uint) : Mount
      {
         return GameData.getObject(MODULE,param1) as Mount;
      }
      
      public static function getMounts() : Array
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
