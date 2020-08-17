package com.ankamagames.dofus.network.messages.game.friend
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.friend.IgnoredInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class IgnoredAddedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5678;
       
      
      private var _isInitialized:Boolean = false;
      
      public var ignoreAdded:IgnoredInformations;
      
      public var session:Boolean = false;
      
      private var _ignoreAddedtree:FuncTree;
      
      public function IgnoredAddedMessage()
      {
         this.ignoreAdded = new IgnoredInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5678;
      }
      
      public function initIgnoredAddedMessage(param1:IgnoredInformations = null, param2:Boolean = false) : IgnoredAddedMessage
      {
         this.ignoreAdded = param1;
         this.session = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.ignoreAdded = new IgnoredInformations();
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
         this.serializeAs_IgnoredAddedMessage(param1);
      }
      
      public function serializeAs_IgnoredAddedMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.ignoreAdded.getTypeId());
         this.ignoreAdded.serialize(param1);
         param1.writeBoolean(this.session);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_IgnoredAddedMessage(param1);
      }
      
      public function deserializeAs_IgnoredAddedMessage(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.ignoreAdded = ProtocolTypeManager.getInstance(IgnoredInformations,_loc2_);
         this.ignoreAdded.deserialize(param1);
         this._sessionFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_IgnoredAddedMessage(param1);
      }
      
      public function deserializeAsyncAs_IgnoredAddedMessage(param1:FuncTree) : void
      {
         this._ignoreAddedtree = param1.addChild(this._ignoreAddedtreeFunc);
         param1.addChild(this._sessionFunc);
      }
      
      private function _ignoreAddedtreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.ignoreAdded = ProtocolTypeManager.getInstance(IgnoredInformations,_loc2_);
         this.ignoreAdded.deserializeAsync(this._ignoreAddedtree);
      }
      
      private function _sessionFunc(param1:ICustomDataInput) : void
      {
         this.session = param1.readBoolean();
      }
   }
}
