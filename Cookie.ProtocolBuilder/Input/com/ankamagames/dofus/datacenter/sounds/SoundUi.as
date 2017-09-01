package com.ankamagames.dofus.datacenter.sounds
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class SoundUi implements IDataCenter
   {
      
      public static var MODULE:String = "SoundUi";
       
      
      public var id:uint;
      
      public var uiName:String;
      
      public var openFile:String;
      
      public var closeFile:String;
      
      public var subElements:Vector.<SoundUiElement>;
      
      public function SoundUi()
      {
         super();
      }
      
      public static function getSoundUiById(param1:uint) : SoundUi
      {
         var _loc2_:SoundUi = GameData.getObject(MODULE,param1) as SoundUi;
         return _loc2_;
      }
      
      public static function getSoundUis() : Array
      {
         return GameData.getObjects(MODULE);
      }
   }
}
