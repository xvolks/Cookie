package com.ankamagames.dofus.network.messages.connection
{
   import com.ankamagames.dofus.network.types.connection.GameServerInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class SelectedServerDataExtendedMessage extends SelectedServerDataMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6469;
       
      
      private var _isInitialized:Boolean = false;
      
      public var servers:Vector.<GameServerInformations>;
      
      private var _serverstree:FuncTree;
      
      public function SelectedServerDataExtendedMessage()
      {
         this.servers = new Vector.<GameServerInformations>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6469;
      }
      
      public function initSelectedServerDataExtendedMessage(param1:uint = 0, param2:String = "", param3:uint = 0, param4:Boolean = false, param5:Vector.<int> = null, param6:Vector.<GameServerInformations> = null) : SelectedServerDataExtendedMessage
      {
         super.initSelectedServerDataMessage(param1,param2,param3,param4,param5);
         this.servers = param6;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.servers = new Vector.<GameServerInformations>();
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
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_SelectedServerDataExtendedMessage(param1);
      }
      
      public function serializeAs_SelectedServerDataExtendedMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_SelectedServerDataMessage(param1);
         param1.writeShort(this.servers.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.servers.length)
         {
            (this.servers[_loc2_] as GameServerInformations).serializeAs_GameServerInformations(param1);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_SelectedServerDataExtendedMessage(param1);
      }
      
      public function deserializeAs_SelectedServerDataExtendedMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:GameServerInformations = null;
         super.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new GameServerInformations();
            _loc4_.deserialize(param1);
            this.servers.push(_loc4_);
            _loc3_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_SelectedServerDataExtendedMessage(param1);
      }
      
      public function deserializeAsyncAs_SelectedServerDataExtendedMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._serverstree = param1.addChild(this._serverstreeFunc);
      }
      
      private function _serverstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._serverstree.addChild(this._serversFunc);
            _loc3_++;
         }
      }
      
      private function _serversFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:GameServerInformations = new GameServerInformations();
         _loc2_.deserialize(param1);
         this.servers.push(_loc2_);
      }
   }
}
