package com.ankamagames.dofus.datacenter.items
{
   import com.ankamagames.dofus.datacenter.effects.EffectInstance;
   import com.ankamagames.jerakine.data.GameData;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   
   public class ItemSet#2584 implements IDataCenter
   {
      
      public static const MODULE:String = "ItemSets";
       
      
      public var id:uint;
      
      public var items:Vector.<uint>;
      
      public var nameId:uint;
      
      public var effects:Vector.<Vector.<EffectInstance>>;
      
      public var bonusIsSecret:Boolean;
      
      private var _name:String;
      
      public function ItemSet#2584()
      {
         super();
      }
      
      public static function getItemSetById(param1:uint) : ItemSet#2584
      {
         return GameData.getObject(MODULE,param1) as ItemSet#2584;
      }
      
      public static function getItemSets() : Array
      {
         return GameData.getObjects(MODULE);
      }
      
      public function get name() : String
      {
         if(!this._name)
         {
            this._name = I18n.getText(this.nameId);
         }
         return this._name;
      }
   }
}
