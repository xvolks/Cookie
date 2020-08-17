package com.ankamagames.dofus.network.messages.game.social
{
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ContactLookMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5934;
       
      
      private var _isInitialized:Boolean = false;
      
      public var requestId:uint = 0;
      
      public var playerName:String = "";
      
      public var playerId:Number = 0;
      
      public var look:EntityLook;
      
      private var _looktree:FuncTree;
      
      public function ContactLookMessage()
      {
         this.look = new EntityLook();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5934;
      }
      
      public function initContactLookMessage(param1:uint = 0, param2:String = "", param3:Number = 0, param4:EntityLook = null) : ContactLookMessage
      {
         this.requestId = param1;
         this.playerName = param2;
         this.playerId = param3;
         this.look = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.requestId = 0;
         this.playerName = "";
         this.playerId = 0;
         this.look = new EntityLook();
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
         this.serializeAs_ContactLookMessage(param1);
      }
      
      public function serializeAs_ContactLookMessage(param1:ICustomDataOutput) : void
      {
         if(this.requestId < 0)
         {
            throw new Error("Forbidden value (" + this.requestId + ") on element requestId.");
         }
         param1.writeVarInt(this.requestId);
         param1.writeUTF(this.playerName);
         if(this.playerId < 0 || this.playerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.playerId + ") on element playerId.");
         }
         param1.writeVarLong(this.playerId);
         this.look.serializeAs_EntityLook(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ContactLookMessage(param1);
      }
      
      public function deserializeAs_ContactLookMessage(param1:ICustomDataInput) : void
      {
         this._requestIdFunc(param1);
         this._playerNameFunc(param1);
         this._playerIdFunc(param1);
         this.look = new EntityLook();
         this.look.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ContactLookMessage(param1);
      }
      
      public function deserializeAsyncAs_ContactLookMessage(param1:FuncTree) : void
      {
         param1.addChild(this._requestIdFunc);
         param1.addChild(this._playerNameFunc);
         param1.addChild(this._playerIdFunc);
         this._looktree = param1.addChild(this._looktreeFunc);
      }
      
      private function _requestIdFunc(param1:ICustomDataInput) : void
      {
         this.requestId = param1.readVarUhInt();
         if(this.requestId < 0)
         {
            throw new Error("Forbidden value (" + this.requestId + ") on element of ContactLookMessage.requestId.");
         }
      }
      
      private function _playerNameFunc(param1:ICustomDataInput) : void
      {
         this.playerName = param1.readUTF();
      }
      
      private function _playerIdFunc(param1:ICustomDataInput) : void
      {
         this.playerId = param1.readVarUhLong();
         if(this.playerId < 0 || this.playerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.playerId + ") on element of ContactLookMessage.playerId.");
         }
      }
      
      private function _looktreeFunc(param1:ICustomDataInput) : void
      {
         this.look = new EntityLook();
         this.look.deserializeAsync(this._looktree);
      }
   }
}
