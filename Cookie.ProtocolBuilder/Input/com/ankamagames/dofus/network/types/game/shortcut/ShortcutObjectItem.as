package com.ankamagames.dofus.network.types.game.shortcut
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class ShortcutObjectItem extends ShortcutObject implements INetworkType
   {
      
      public static const protocolId:uint = 371;
       
      
      public var itemUID:int = 0;
      
      public var itemGID:int = 0;
      
      public function ShortcutObjectItem()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 371;
      }
      
      public function initShortcutObjectItem(param1:uint = 0, param2:int = 0, param3:int = 0) : ShortcutObjectItem
      {
         super.initShortcutObject(param1);
         this.itemUID = param2;
         this.itemGID = param3;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.itemUID = 0;
         this.itemGID = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ShortcutObjectItem(param1);
      }
      
      public function serializeAs_ShortcutObjectItem(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ShortcutObject(param1);
         param1.writeInt(this.itemUID);
         param1.writeInt(this.itemGID);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ShortcutObjectItem(param1);
      }
      
      public function deserializeAs_ShortcutObjectItem(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._itemUIDFunc(param1);
         this._itemGIDFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ShortcutObjectItem(param1);
      }
      
      public function deserializeAsyncAs_ShortcutObjectItem(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._itemUIDFunc);
         param1.addChild(this._itemGIDFunc);
      }
      
      private function _itemUIDFunc(param1:ICustomDataInput) : void
      {
         this.itemUID = param1.readInt();
      }
      
      private function _itemGIDFunc(param1:ICustomDataInput) : void
      {
         this.itemGID = param1.readInt();
      }
   }
}
