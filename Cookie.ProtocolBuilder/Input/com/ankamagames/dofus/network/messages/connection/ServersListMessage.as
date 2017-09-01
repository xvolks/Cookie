package com.ankamagames.dofus.network.messages.connection
{
   import com.ankamagames.dofus.network.types.connection.GameServerInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ServersListMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 30;
       
      
      private var _isInitialized:Boolean = false;
      
      public var servers:Vector.<GameServerInformations>;
      
      public var alreadyConnectedToServerId:uint = 0;
      
      public var canCreateNewCharacter:Boolean = false;
      
      private var _serverstree:FuncTree;
      
      public function ServersListMessage()
      {
         this.servers = new Vector.<GameServerInformations>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 30;
      }
      
      public function initServersListMessage(param1:Vector.<GameServerInformations> = null, param2:uint = 0, param3:Boolean = false) : ServersListMessage
      {
         this.servers = param1;
         this.alreadyConnectedToServerId = param2;
         this.canCreateNewCharacter = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.servers = new Vector.<GameServerInformations>();
         this.alreadyConnectedToServerId = 0;
         this.canCreateNewCharacter = false;
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
         this.serializeAs_ServersListMessage(param1);
      }
      
      public function serializeAs_ServersListMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.servers.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.servers.length)
         {
            (this.servers[_loc2_] as GameServerInformations).serializeAs_GameServerInformations(param1);
            _loc2_++;
         }
         if(this.alreadyConnectedToServerId < 0)
         {
            throw new Error("Forbidden value (" + this.alreadyConnectedToServerId + ") on element alreadyConnectedToServerId.");
         }
         param1.writeVarShort(this.alreadyConnectedToServerId);
         param1.writeBoolean(this.canCreateNewCharacter);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ServersListMessage(param1);
      }
      
      public function deserializeAs_ServersListMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:GameServerInformations = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new GameServerInformations();
            _loc4_.deserialize(param1);
            this.servers.push(_loc4_);
            _loc3_++;
         }
         this._alreadyConnectedToServerIdFunc(param1);
         this._canCreateNewCharacterFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ServersListMessage(param1);
      }
      
      public function deserializeAsyncAs_ServersListMessage(param1:FuncTree) : void
      {
         this._serverstree = param1.addChild(this._serverstreeFunc);
         param1.addChild(this._alreadyConnectedToServerIdFunc);
         param1.addChild(this._canCreateNewCharacterFunc);
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
      
      private function _alreadyConnectedToServerIdFunc(param1:ICustomDataInput) : void
      {
         this.alreadyConnectedToServerId = param1.readVarUhShort();
         if(this.alreadyConnectedToServerId < 0)
         {
            throw new Error("Forbidden value (" + this.alreadyConnectedToServerId + ") on element of ServersListMessage.alreadyConnectedToServerId.");
         }
      }
      
      private function _canCreateNewCharacterFunc(param1:ICustomDataInput) : void
      {
         this.canCreateNewCharacter = param1.readBoolean();
      }
   }
}
