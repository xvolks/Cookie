package com.ankamagames.dofus.datacenter.documents
{
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class Comic implements IDataCenter
   {
      
      private static const MODULE:String = "Comics";
       
      
      public var id:int;
      
      public var remoteId:String;
      
      public function Comic()
      {
         super();
      }
      
      public static function getComicById(param1:int) : Comic
      {
         return GameData.getObject(MODULE,param1) as Comic;
      }
      
      public static function getComics() : Array
      {
         return GameData.getObjects(MODULE);
      }
   }
}
