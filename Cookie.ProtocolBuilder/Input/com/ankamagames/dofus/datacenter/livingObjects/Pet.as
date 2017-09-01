package com.ankamagames.dofus.datacenter.livingObjects
{
   import com.ankamagames.dofus.datacenter.effects.EffectInstance;
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   import com.ankamagames.jerakine.logger.Log;
   import com.ankamagames.jerakine.logger.Logger;
   import flash.utils.getQualifiedClassName;
   
   public class Pet implements IDataCenter
   {
      
      public static const MODULE:String = "Pets";
      
      protected static const _log:Logger = Log.getLogger(getQualifiedClassName(Pet));
       
      
      public var id:int;
      
      public var foodItems:Vector.<int>;
      
      public var foodTypes:Vector.<int>;
      
      public var minDurationBeforeMeal:int;
      
      public var maxDurationBeforeMeal:int;
      
      public var possibleEffects:Vector.<EffectInstance>;
      
      public function Pet()
      {
         super();
      }
      
      public static function getPetById(param1:int) : Pet
      {
         return GameData.getObject(MODULE,param1) as Pet;
      }
      
      public static function getPets() : Array
      {
         return GameData.getObjects(MODULE);
      }
   }
}
