package com.ankamagames.dofus.datacenter.sounds
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class SoundAnimation implements IDataCenter
   {
      
      public static var MODULE:String = "SoundAnimations";
       
      
      public var id:uint;
      
      public var name:String;
      
      public var label:String;
      
      public var filename:String;
      
      public var volume:int;
      
      public var rolloff:int;
      
      public var automationDuration:int;
      
      public var automationVolume:int;
      
      public var automationFadeIn:int;
      
      public var automationFadeOut:int;
      
      public var noCutSilence:Boolean;
      
      public var startFrame:uint;
      
      public function SoundAnimation()
      {
         super();
      }
      
      public static function getSoundAnimationById(param1:uint) : SoundAnimation
      {
         return GameData.getObject(MODULE,param1) as SoundAnimation;
      }
      
      public static function getSoundAnimations() : Array
      {
         return GameData.getObjects(MODULE);
      }
   }
}
