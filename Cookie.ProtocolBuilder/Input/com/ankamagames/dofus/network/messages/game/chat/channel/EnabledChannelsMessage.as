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
   public class EnabledChannelsMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 892;
       
      
      private var _isInitialized:Boolean = false;
      
      public var channels:Vector.<uint>;
      
      public var disallowed:Vector.<uint>;
      
      private var _channelstree:FuncTree;
      
      private var _disallowedtree:FuncTree;
      
      public function EnabledChannelsMessage()
      {
         this.channels = new Vector.<uint>();
         this.disallowed = new Vector.<uint>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 892;
      }
      
      public function initEnabledChannelsMessage(param1:Vector.<uint> = null, param2:Vector.<uint> = null) : EnabledChannelsMessage
      {
         this.channels = param1;
         this.disallowed = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.channels = new Vector.<uint>();
         this.disallowed = new Vector.<uint>();
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
         this.serializeAs_EnabledChannelsMessage(param1);
      }
      
      public function serializeAs_EnabledChannelsMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.channels.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.channels.length)
         {
            param1.writeByte(this.channels[_loc2_]);
            _loc2_++;
         }
         param1.writeShort(this.disallowed.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.disallowed.length)
         {
            param1.writeByte(this.disallowed[_loc3_]);
            _loc3_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_EnabledChannelsMessage(param1);
      }
      
      public function deserializeAs_EnabledChannelsMessage(param1:ICustomDataInput) : void
      {
         var _loc6_:uint = 0;
         var _loc7_:uint = 0;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = param1.readByte();
            if(_loc6_ < 0)
            {
               throw new Error("Forbidden value (" + _loc6_ + ") on elements of channels.");
            }
            this.channels.push(_loc6_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc7_ = param1.readByte();
            if(_loc7_ < 0)
            {
               throw new Error("Forbidden value (" + _loc7_ + ") on elements of disallowed.");
            }
            this.disallowed.push(_loc7_);
            _loc5_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_EnabledChannelsMessage(param1);
      }
      
      public function deserializeAsyncAs_EnabledChannelsMessage(param1:FuncTree) : void
      {
         this._channelstree = param1.addChild(this._channelstreeFunc);
         this._disallowedtree = param1.addChild(this._disallowedtreeFunc);
      }
      
      private function _channelstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._channelstree.addChild(this._channelsFunc);
            _loc3_++;
         }
      }
      
      private function _channelsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of channels.");
         }
         this.channels.push(_loc2_);
      }
      
      private function _disallowedtreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._disallowedtree.addChild(this._disallowedFunc);
            _loc3_++;
         }
      }
      
      private function _disallowedFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of disallowed.");
         }
         this.disallowed.push(_loc2_);
      }
   }
}
