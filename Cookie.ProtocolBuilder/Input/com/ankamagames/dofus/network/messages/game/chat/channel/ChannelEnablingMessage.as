package com.ankamagames.dofus.network.messages.game.chat.channel
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ChannelEnablingMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 890;
       
      
      private var _isInitialized:Boolean = false;
      
      public var channel:uint = 0;
      
      public var enable:Boolean = false;
      
      public function ChannelEnablingMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 890;
      }
      
      public function initChannelEnablingMessage(param1:uint = 0, param2:Boolean = false) : ChannelEnablingMessage
      {
         this.channel = param1;
         this.enable = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.channel = 0;
         this.enable = false;
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
         this.serializeAs_ChannelEnablingMessage(param1);
      }
      
      public function serializeAs_ChannelEnablingMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.channel);
         param1.writeBoolean(this.enable);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ChannelEnablingMessage(param1);
      }
      
      public function deserializeAs_ChannelEnablingMessage(param1:ICustomDataInput) : void
      {
         this._channelFunc(param1);
         this._enableFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ChannelEnablingMessage(param1);
      }
      
      public function deserializeAsyncAs_ChannelEnablingMessage(param1:FuncTree) : void
      {
         param1.addChild(this._channelFunc);
         param1.addChild(this._enableFunc);
      }
      
      private function _channelFunc(param1:ICustomDataInput) : void
      {
         this.channel = param1.readByte();
         if(this.channel < 0)
         {
            throw new Error("Forbidden value (" + this.channel + ") on element of ChannelEnablingMessage.channel.");
         }
      }
      
      private function _enableFunc(param1:ICustomDataInput) : void
      {
         this.enable = param1.readBoolean();
      }
   }
}
