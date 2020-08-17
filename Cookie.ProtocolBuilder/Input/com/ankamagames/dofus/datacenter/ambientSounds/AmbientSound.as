package com.ankamagames.dofus.datacenter.ambientSounds
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class AmbientSound extends PlaylistSound implements IDataCenter
   {
      
      public static const AMBIENT_TYPE_ROLEPLAY:int = 1;
      
      public static const AMBIENT_TYPE_AMBIENT:int = 2;
      
      public static const AMBIENT_TYPE_FIGHT:int = 3;
      
      public static const AMBIENT_TYPE_BOSS:int = 4;
      
      public static const MODULE:String = "AmbientSounds";
       
      
      public var criterionId:int;
      
      public var silenceMin:uint;
      
      public var silenceMax:uint;
      
      public var type_id:int;
      
      public function AmbientSound()
      {
         super();
      }
      
      public static function getAmbientSoundById(param1:uint) : AmbientSound
      {
         return GameData.getObject(MODULE,param1) as AmbientSound;
      }
   }
}
