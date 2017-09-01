package com.ankamagames.dofus.datacenter.appearance
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class Appearance implements IDataCenter
   {
      
      public static const MODULE:String = "Appearances";
       
      
      public var id:uint;
      
      public var type:uint;
      
      public var data:String;
      
      public function Appearance()
      {
         super();
      }
      
      public static function getAppearanceById(param1:uint) : Appearance
      {
         return GameData.getObject(MODULE,param1) as Appearance;
      }
   }
}
