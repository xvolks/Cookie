package com.ankamagames.dofus.datacenter.communication
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   import com.ankamagames.jerakine.logger.Log;
   import com.ankamagames.jerakine.logger.Logger;
   import flash.utils.getQualifiedClassName;
   
   public class NamingRule implements IDataCenter
   {
      
      public static const MODULE:String = "NamingRules";
      
      protected static const _log:Logger = Log.getLogger(getQualifiedClassName(NamingRule));
       
      
      public var id:uint;
      
      public var minLength:uint;
      
      public var maxLength:uint;
      
      public var regexp:String;
      
      public function NamingRule()
      {
         super();
      }
      
      public static function getNamingRuleById(param1:int) : NamingRule
      {
         return GameData.getObject(MODULE,param1) as NamingRule;
      }
      
      public static function getNamingRules() : Array
      {
         return GameData.getObjects(MODULE);
      }
   }
}
