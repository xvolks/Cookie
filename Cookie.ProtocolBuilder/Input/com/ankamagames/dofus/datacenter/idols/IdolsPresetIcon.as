package com.ankamagames.dofus.datacenter.idols
{
   import com.ankamagames.jerakine.data.GameData;
   
   public class IdolsPresetIcon
   {
      
      public static const MODULE:String = "IdolsPresetIcons";
       
      
      public var id:int;
      
      public var order:int;
      
      public function IdolsPresetIcon()
      {
         super();
      }
      
      public static function getIdolsPresetIconById(param1:int) : IdolsPresetIcon
      {
         return GameData.getObject(MODULE,param1) as IdolsPresetIcon;
      }
      
      public static function getIdolsPresetIcons() : Array
      {
         return GameData.getObjects(MODULE);
      }
   }
}
