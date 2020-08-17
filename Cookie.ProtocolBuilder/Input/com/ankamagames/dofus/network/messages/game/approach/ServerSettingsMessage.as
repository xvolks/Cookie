package com.ankamagames.dofus.network.messages.game.approach
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ServerSettingsMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6340;
       
      
      private var _isInitialized:Boolean = false;
      
      public var lang:String = "";
      
      public var community:uint = 0;
      
      public var gameType:int = -1;
      
      public var arenaLeaveBanTime:uint = 0;
      
      public function ServerSettingsMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6340;
      }
      
      public function initServerSettingsMessage(param1:String = "", param2:uint = 0, param3:int = -1, param4:uint = 0) : ServerSettingsMessage
      {
         this.lang = param1;
         this.community = param2;
         this.gameType = param3;
         this.arenaLeaveBanTime = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.lang = "";
         this.community = 0;
         this.gameType = -1;
         this.arenaLeaveBanTime = 0;
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
         this.serializeAs_ServerSettingsMessage(param1);
      }
      
      public function serializeAs_ServerSettingsMessage(param1:ICustomDataOutput) : void
      {
         param1.writeUTF(this.lang);
         if(this.community < 0)
         {
            throw new Error("Forbidden value (" + this.community + ") on element community.");
         }
         param1.writeByte(this.community);
         param1.writeByte(this.gameType);
         if(this.arenaLeaveBanTime < 0)
         {
            throw new Error("Forbidden value (" + this.arenaLeaveBanTime + ") on element arenaLeaveBanTime.");
         }
         param1.writeVarShort(this.arenaLeaveBanTime);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ServerSettingsMessage(param1);
      }
      
      public function deserializeAs_ServerSettingsMessage(param1:ICustomDataInput) : void
      {
         this._langFunc(param1);
         this._communityFunc(param1);
         this._gameTypeFunc(param1);
         this._arenaLeaveBanTimeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ServerSettingsMessage(param1);
      }
      
      public function deserializeAsyncAs_ServerSettingsMessage(param1:FuncTree) : void
      {
         param1.addChild(this._langFunc);
         param1.addChild(this._communityFunc);
         param1.addChild(this._gameTypeFunc);
         param1.addChild(this._arenaLeaveBanTimeFunc);
      }
      
      private function _langFunc(param1:ICustomDataInput) : void
      {
         this.lang = param1.readUTF();
      }
      
      private function _communityFunc(param1:ICustomDataInput) : void
      {
         this.community = param1.readByte();
         if(this.community < 0)
         {
            throw new Error("Forbidden value (" + this.community + ") on element of ServerSettingsMessage.community.");
         }
      }
      
      private function _gameTypeFunc(param1:ICustomDataInput) : void
      {
         this.gameType = param1.readByte();
      }
      
      private function _arenaLeaveBanTimeFunc(param1:ICustomDataInput) : void
      {
         this.arenaLeaveBanTime = param1.readVarUhShort();
         if(this.arenaLeaveBanTime < 0)
         {
            throw new Error("Forbidden value (" + this.arenaLeaveBanTime + ") on element of ServerSettingsMessage.arenaLeaveBanTime.");
         }
      }
   }
}
