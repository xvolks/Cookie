package com.ankamagames.dofus.network.messages.connection
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class HelloConnectMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 3;
       
      
      private var _isInitialized:Boolean = false;
      
      [Transient]
      public var salt:String = "";
      
      public var key:Vector.<int>;
      
      private var _keytree:FuncTree;
      
      public function HelloConnectMessage()
      {
         this.key = new Vector.<int>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 3;
      }
      
      public function initHelloConnectMessage(param1:String = "", param2:Vector.<int> = null) : HelloConnectMessage
      {
         this.salt = param1;
         this.key = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.salt = "";
         this.key = new Vector.<int>();
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
         this.serializeAs_HelloConnectMessage(param1);
      }
      
      public function serializeAs_HelloConnectMessage(param1:ICustomDataOutput) : void
      {
         param1.writeUTF(this.salt);
         param1.writeVarInt(this.key.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.key.length)
         {
            param1.writeByte(this.key[_loc2_]);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HelloConnectMessage(param1);
      }
      
      public function deserializeAs_HelloConnectMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:int = 0;
         this._saltFunc(param1);
         var _loc2_:uint = param1.readVarInt();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readByte();
            this.key.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HelloConnectMessage(param1);
      }
      
      public function deserializeAsyncAs_HelloConnectMessage(param1:FuncTree) : void
      {
         param1.addChild(this._saltFunc);
         this._keytree = param1.addChild(this._keytreeFunc);
      }
      
      private function _saltFunc(param1:ICustomDataInput) : void
      {
         this.salt = param1.readUTF();
      }
      
      private function _keytreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarInt();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._keytree.addChild(this._keyFunc);
            _loc3_++;
         }
      }
      
      private function _keyFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:int = param1.readByte();
         this.key.push(_loc2_);
      }
   }
}
