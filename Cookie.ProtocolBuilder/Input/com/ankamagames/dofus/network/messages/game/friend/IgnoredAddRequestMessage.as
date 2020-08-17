package com.ankamagames.dofus.network.messages.game.friend
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class IgnoredAddRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5673;
       
      
      private var _isInitialized:Boolean = false;
      
      public var name:String = "";
      
      public var session:Boolean = false;
      
      public function IgnoredAddRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5673;
      }
      
      public function initIgnoredAddRequestMessage(param1:String = "", param2:Boolean = false) : IgnoredAddRequestMessage
      {
         this.name = param1;
         this.session = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.name = "";
         this.session = false;
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
         this.serializeAs_IgnoredAddRequestMessage(param1);
      }
      
      public function serializeAs_IgnoredAddRequestMessage(param1:ICustomDataOutput) : void
      {
         param1.writeUTF(this.name);
         param1.writeBoolean(this.session);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_IgnoredAddRequestMessage(param1);
      }
      
      public function deserializeAs_IgnoredAddRequestMessage(param1:ICustomDataInput) : void
      {
         this._nameFunc(param1);
         this._sessionFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_IgnoredAddRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_IgnoredAddRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._nameFunc);
         param1.addChild(this._sessionFunc);
      }
      
      private function _nameFunc(param1:ICustomDataInput) : void
      {
         this.name = param1.readUTF();
      }
      
      private function _sessionFunc(param1:ICustomDataInput) : void
      {
         this.session = param1.readBoolean();
      }
   }
}
