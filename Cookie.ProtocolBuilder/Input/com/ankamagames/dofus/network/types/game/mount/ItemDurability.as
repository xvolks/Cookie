package com.ankamagames.dofus.network.types.game.mount
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class ItemDurability implements INetworkType
   {
      
      public static const protocolId:uint = 168;
       
      
      public var durability:int = 0;
      
      public var durabilityMax:int = 0;
      
      public function ItemDurability()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 168;
      }
      
      public function initItemDurability(param1:int = 0, param2:int = 0) : ItemDurability
      {
         this.durability = param1;
         this.durabilityMax = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.durability = 0;
         this.durabilityMax = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ItemDurability(param1);
      }
      
      public function serializeAs_ItemDurability(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.durability);
         param1.writeShort(this.durabilityMax);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ItemDurability(param1);
      }
      
      public function deserializeAs_ItemDurability(param1:ICustomDataInput) : void
      {
         this._durabilityFunc(param1);
         this._durabilityMaxFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ItemDurability(param1);
      }
      
      public function deserializeAsyncAs_ItemDurability(param1:FuncTree) : void
      {
         param1.addChild(this._durabilityFunc);
         param1.addChild(this._durabilityMaxFunc);
      }
      
      private function _durabilityFunc(param1:ICustomDataInput) : void
      {
         this.durability = param1.readShort();
      }
      
      private function _durabilityMaxFunc(param1:ICustomDataInput) : void
      {
         this.durabilityMax = param1.readShort();
      }
   }
}
