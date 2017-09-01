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
   public class MountReleasedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6308;
       
      
      private var _isInitialized:Boolean = false;
      
      public var mountId:int = 0;
      
      public function MountReleasedMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6308;
      }
      
      public function initMountReleasedMessage(param1:int = 0) : MountReleasedMessage
      {
         this.mountId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.mountId = 0;
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
         this.serializeAs_MountReleasedMessage(param1);
      }
      
      public function serializeAs_MountReleasedMessage(param1:ICustomDataOutput) : void
      {
         param1.writeVarInt(this.mountId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MountReleasedMessage(param1);
      }
      
      public function deserializeAs_MountReleasedMessage(param1:ICustomDataInput) : void
      {
         this._mountIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MountReleasedMessage(param1);
      }
      
      public function deserializeAsyncAs_MountReleasedMessage(param1:FuncTree) : void
      {
         param1.addChild(this._mountIdFunc);
      }
      
      private function _mountIdFunc(param1:ICustomDataInput) : void
      {
         this.mountId = param1.readVarInt();
      }
   }
}
