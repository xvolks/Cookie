package com.ankamagames.dofus.datacenter.alignments
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   import com.ankamagames.jerakine.logger.Log;
   import com.ankamagames.jerakine.logger.Logger;
   import flash.utils.getQualifiedClassName;
   
   public class AlignmentTitle implements IDataCenter
   {
      
      public static const MODULE:String = "AlignmentTitles";
      
      protected static const _log:Logger = Log.getLogger(getQualifiedClassName(AlignmentTitle));
       
      
      public var sideId:int;
      
      public var namesId:Vector.<int>;
      
      public var shortsId:Vector.<int>;
      
      public function AlignmentTitle()
      {
         super();
      }
      
      public static function getAlignmentTitlesById(param1:int) : AlignmentTitle
      {
         return GameData.getObject(MODULE,param1) as AlignmentTitle;
      }
      
      public static function getAlignmentTitles() : Array
      {
         return GameData.getObjects(MODULE);
      }
      
      public function getNameFromGrade(param1:int) : String
      {
         return I18n.getText(this.namesId[param1]);
      }
      
      public function getShortNameFromGrade(param1:int) : String
      {
         return I18n.getText(this.shortsId[param1]);
      }
   }
}
