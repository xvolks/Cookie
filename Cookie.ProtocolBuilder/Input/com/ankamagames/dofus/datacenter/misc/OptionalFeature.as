package com.ankamagames.dofus.datacenter.misc
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   import flash.utils.Dictionary;
   
   public class OptionalFeature implements IDataCenter
   {
      
      public static const MODULE:String = "OptionalFeatures";
      
      private static var _keywords:Dictionary;
       
      
      public var id:int;
      
      public var keyword:String;
      
      public function OptionalFeature()
      {
         super();
      }
      
      public static function getOptionalFeatureById(param1:int) : OptionalFeature
      {
         return GameData.getObject(MODULE,param1) as OptionalFeature;
      }
      
      public static function getOptionalFeatureByKeyword(param1:String) : OptionalFeature
      {
         var _loc2_:OptionalFeature = null;
         if(!_keywords || !_keywords[param1])
         {
            _keywords = new Dictionary();
            for each(_loc2_ in getAllOptionalFeatures())
            {
               _keywords[_loc2_.keyword] = _loc2_;
            }
         }
         return _keywords[param1];
      }
      
      public static function getAllOptionalFeatures() : Array
      {
         return GameData.getObjects(MODULE);
      }
   }
}
