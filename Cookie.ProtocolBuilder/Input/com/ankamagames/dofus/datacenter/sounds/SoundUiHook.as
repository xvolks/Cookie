package com.ankamagames.dofus.datacenter.sounds
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class SoundUiHook implements IDataCenter
   {
      
      public static var MODULE:String = "SoundUiHook";
       
      
      public var id:uint;
      
      public var name:String;
      
      public function SoundUiHook()
      {
         super();
      }
      
      public static function getSoundUiHookById(param1:uint) : SoundUiHook
      {
         return GameData.getObject(MODULE,param1) as SoundUiHook;
      }
      
      public static function getSoundUiHooks() : Array
      {
         return GameData.getObjects(MODULE);
      }
   }
}
