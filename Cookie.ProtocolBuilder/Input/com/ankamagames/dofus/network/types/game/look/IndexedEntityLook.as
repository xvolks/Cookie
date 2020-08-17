package com.ankamagames.dofus.network.types.game.look
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class IndexedEntityLook implements INetworkType
   {
      
      public static const protocolId:uint = 405;
       
      
      public var look:EntityLook;
      
      public var index:uint = 0;
      
      private var _looktree:FuncTree;
      
      public function IndexedEntityLook()
      {
         this.look = new EntityLook();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 405;
      }
      
      public function initIndexedEntityLook(param1:EntityLook = null, param2:uint = 0) : IndexedEntityLook
      {
         this.look = param1;
         this.index = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.look = new EntityLook();
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_IndexedEntityLook(param1);
      }
      
      public function serializeAs_IndexedEntityLook(param1:ICustomDataOutput) : void
      {
         this.look.serializeAs_EntityLook(param1);
         if(this.index < 0)
         {
            throw new Error("Forbidden value (" + this.index + ") on element index.");
         }
         param1.writeByte(this.index);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_IndexedEntityLook(param1);
      }
      
      public function deserializeAs_IndexedEntityLook(param1:ICustomDataInput) : void
      {
         this.look = new EntityLook();
         this.look.deserialize(param1);
         this._indexFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_IndexedEntityLook(param1);
      }
      
      public function deserializeAsyncAs_IndexedEntityLook(param1:FuncTree) : void
      {
         this._looktree = param1.addChild(this._looktreeFunc);
         param1.addChild(this._indexFunc);
      }
      
      private function _looktreeFunc(param1:ICustomDataInput) : void
      {
         this.look = new EntityLook();
         this.look.deserializeAsync(this._looktree);
      }
      
      private function _indexFunc(param1:ICustomDataInput) : void
      {
         this.index = param1.readByte();
         if(this.index < 0)
         {
            throw new Error("Forbidden value (" + this.index + ") on element of IndexedEntityLook.index.");
         }
      }
   }
}
