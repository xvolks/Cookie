package com.ankamagames.dofus.datacenter.misc
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.data.ICensoredDataItem;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class CensoredContent implements ICensoredDataItem, IDataCenter
   {
      
      public static const MODULE:String = "CensoredContents";
       
      
      private var _type:int;
      
      private var _oldValue:int;
      
      private var _newValue:int;
      
      private var _lang:String;
      
      public function CensoredContent()
      {
         super();
      }
      
      public static function getCensoredContents() : Array
      {
         return GameData.getObjects(MODULE);
      }
      
      public function get lang() : String
      {
         return this._lang;
      }
      
      public function set lang(param1:String) : void
      {
         this._lang = param1;
      }
      
      public function set type(param1:int) : void
      {
         this._type = param1;
      }
      
      public function get type() : int
      {
         return this._type;
      }
      
      public function set oldValue(param1:int) : void
      {
         this._oldValue = param1;
      }
      
      public function get oldValue() : int
      {
         return this._oldValue;
      }
      
      public function set newValue(param1:int) : void
      {
         this._newValue = param1;
      }
      
      public function get newValue() : int
      {
         return this._newValue;
      }
   }
}
