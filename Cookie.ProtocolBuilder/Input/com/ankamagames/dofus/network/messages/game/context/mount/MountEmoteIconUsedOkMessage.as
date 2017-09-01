package com.ankamagames.dofus.network.messages.game.context.mount
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class MountEmoteIconUsedOkMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5978;
       
      
      private var _isInitialized:Boolean = false;
      
      public var mountId:int = 0;
      
      public var reactionType:uint = 0;
      
      public function MountEmoteIconUsedOkMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5978;
      }
      
      public function initMountEmoteIconUsedOkMessage(param1:int = 0, param2:uint = 0) : MountEmoteIconUsedOkMessage
      {
         this.mountId = param1;
         this.reactionType = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.mountId = 0;
         this.reactionType = 0;
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_MountEmoteIconUsedOkMessage(param1);
      }
      
      public function serializeAs_MountEmoteIconUsedOkMessage(param1:ICustomDataOutput) : void
      {
         param1.writeVarInt(this.mountId);
         if(this.reactionType < 0)
         {
            throw new Error("Forbidden value (" + this.reactionType + ") on element reactionType.");
         }
         param1.writeByte(this.reactionType);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MountEmoteIconUsedOkMessage(param1);
      }
      
      public function deserializeAs_MountEmoteIconUsedOkMessage(param1:ICustomDataInput) : void
      {
         this._mountIdFunc(param1);
         this._reactionTypeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MountEmoteIconUsedOkMessage(param1);
      }
      
      public function deserializeAsyncAs_MountEmoteIconUsedOkMessage(param1:FuncTree) : void
      {
         param1.addChild(this._mountIdFunc);
         param1.addChild(this._reactionTypeFunc);
      }
      
      private function _mountIdFunc(param1:ICustomDataInput) : void
      {
         this.mountId = param1.readVarInt();
      }
      
      private function _reactionTypeFunc(param1:ICustomDataInput) : void
      {
         this.reactionType = param1.readByte();
         if(this.reactionType < 0)
         {
            throw new Error("Forbidden value (" + this.reactionType + ") on element of MountEmoteIconUsedOkMessage.reactionType.");
         }
      }
   }
}
