package com.ankamagames.dofus.network.types.game.paddock
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.ObjectItemInRolePlay;
   import com.ankamagames.dofus.network.types.game.mount.ItemDurability;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class PaddockItem extends ObjectItemInRolePlay implements INetworkType
   {
      
      public static const protocolId:uint = 185;
       
      
      public var durability:ItemDurability;
      
      private var _durabilitytree:FuncTree;
      
      public function PaddockItem()
      {
         this.durability = new ItemDurability();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 185;
      }
      
      public function initPaddockItem(param1:uint = 0, param2:uint = 0, param3:ItemDurability = null) : PaddockItem
      {
         super.initObjectItemInRolePlay(param1,param2);
         this.durability = param3;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.durability = new ItemDurability();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_PaddockItem(param1);
      }
      
      public function serializeAs_PaddockItem(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ObjectItemInRolePlay(param1);
         this.durability.serializeAs_ItemDurability(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PaddockItem(param1);
      }
      
      public function deserializeAs_PaddockItem(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.durability = new ItemDurability();
         this.durability.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PaddockItem(param1);
      }
      
      public function deserializeAsyncAs_PaddockItem(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._durabilitytree = param1.addChild(this._durabilitytreeFunc);
      }
      
      private function _durabilitytreeFunc(param1:ICustomDataInput) : void
      {
         this.durability = new ItemDurability();
         this.durability.deserializeAsync(this._durabilitytree);
      }
   }
}
