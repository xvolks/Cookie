package com.ankamagames.dofus.network.messages.connection
{
   import com.ankamagames.dofus.network.types.version.VersionExtended;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.BooleanByteWrapper;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class IdentificationMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 4;
       
      
      private var _isInitialized:Boolean = false;
      
      public var version:VersionExtended;
      
      public var lang:String = "";
      
      public var credentials:Vector.<int>;
      
      public var serverId:int = 0;
      
      public var autoconnect:Boolean = false;
      
      public var useCertificate:Boolean = false;
      
      public var useLoginToken:Boolean = false;
      
      public var sessionOptionalSalt:Number = 0;
      
      public var failedAttempts:Vector.<uint>;
      
      private var _versiontree:FuncTree;
      
      private var _credentialstree:FuncTree;
      
      private var _failedAttemptstree:FuncTree;
      
      public function IdentificationMessage()
      {
         this.version = new VersionExtended();
         this.credentials = new Vector.<int>();
         this.failedAttempts = new Vector.<uint>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 4;
      }
      
      public function initIdentificationMessage(param1:VersionExtended = null, param2:String = "", param3:Vector.<int> = null, param4:int = 0, param5:Boolean = false, param6:Boolean = false, param7:Boolean = false, param8:Number = 0, param9:Vector.<uint> = null) : IdentificationMessage
      {
         this.version = param1;
         this.lang = param2;
         this.credentials = param3;
         this.serverId = param4;
         this.autoconnect = param5;
         this.useCertificate = param6;
         this.useLoginToken = param7;
         this.sessionOptionalSalt = param8;
         this.failedAttempts = param9;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.version = new VersionExtended();
         this.credentials = new Vector.<int>();
         this.serverId = 0;
         this.autoconnect = false;
         this.useCertificate = false;
         this.useLoginToken = false;
         this.sessionOptionalSalt = 0;
         this.failedAttempts = new Vector.<uint>();
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
         this.serializeAs_IdentificationMessage(param1);
      }
      
      public function serializeAs_IdentificationMessage(param1:ICustomDataOutput) : void
      {
         var _loc2_:uint = 0;
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,0,this.autoconnect);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,1,this.useCertificate);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,2,this.useLoginToken);
         param1.writeByte(_loc2_);
         this.version.serializeAs_VersionExtended(param1);
         param1.writeUTF(this.lang);
         param1.writeVarInt(this.credentials.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.credentials.length)
         {
            param1.writeByte(this.credentials[_loc3_]);
            _loc3_++;
         }
         param1.writeShort(this.serverId);
         if(this.sessionOptionalSalt < -9007199254740990 || this.sessionOptionalSalt > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.sessionOptionalSalt + ") on element sessionOptionalSalt.");
         }
         param1.writeVarLong(this.sessionOptionalSalt);
         param1.writeShort(this.failedAttempts.length);
         var _loc4_:uint = 0;
         while(_loc4_ < this.failedAttempts.length)
         {
            if(this.failedAttempts[_loc4_] < 0)
            {
               throw new Error("Forbidden value (" + this.failedAttempts[_loc4_] + ") on element 9 (starting at 1) of failedAttempts.");
            }
            param1.writeVarShort(this.failedAttempts[_loc4_]);
            _loc4_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_IdentificationMessage(param1);
      }
      
      public function deserializeAs_IdentificationMessage(param1:ICustomDataInput) : void
      {
         var _loc6_:int = 0;
         var _loc7_:uint = 0;
         this.deserializeByteBoxes(param1);
         this.version = new VersionExtended();
         this.version.deserialize(param1);
         this._langFunc(param1);
         var _loc2_:uint = param1.readVarInt();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = param1.readByte();
            this.credentials.push(_loc6_);
            _loc3_++;
         }
         this._serverIdFunc(param1);
         this._sessionOptionalSaltFunc(param1);
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc7_ = param1.readVarUhShort();
            if(_loc7_ < 0)
            {
               throw new Error("Forbidden value (" + _loc7_ + ") on elements of failedAttempts.");
            }
            this.failedAttempts.push(_loc7_);
            _loc5_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_IdentificationMessage(param1);
      }
      
      public function deserializeAsyncAs_IdentificationMessage(param1:FuncTree) : void
      {
         param1.addChild(this.deserializeByteBoxes);
         this._versiontree = param1.addChild(this._versiontreeFunc);
         param1.addChild(this._langFunc);
         this._credentialstree = param1.addChild(this._credentialstreeFunc);
         param1.addChild(this._serverIdFunc);
         param1.addChild(this._sessionOptionalSaltFunc);
         this._failedAttemptstree = param1.addChild(this._failedAttemptstreeFunc);
      }
      
      private function deserializeByteBoxes(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         this.autoconnect = BooleanByteWrapper.getFlag(_loc2_,0);
         this.useCertificate = BooleanByteWrapper.getFlag(_loc2_,1);
         this.useLoginToken = BooleanByteWrapper.getFlag(_loc2_,2);
      }
      
      private function _versiontreeFunc(param1:ICustomDataInput) : void
      {
         this.version = new VersionExtended();
         this.version.deserializeAsync(this._versiontree);
      }
      
      private function _langFunc(param1:ICustomDataInput) : void
      {
         this.lang = param1.readUTF();
      }
      
      private function _credentialstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarInt();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._credentialstree.addChild(this._credentialsFunc);
            _loc3_++;
         }
      }
      
      private function _credentialsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:int = param1.readByte();
         this.credentials.push(_loc2_);
      }
      
      private function _serverIdFunc(param1:ICustomDataInput) : void
      {
         this.serverId = param1.readShort();
      }
      
      private function _sessionOptionalSaltFunc(param1:ICustomDataInput) : void
      {
         this.sessionOptionalSalt = param1.readVarLong();
         if(this.sessionOptionalSalt < -9007199254740990 || this.sessionOptionalSalt > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.sessionOptionalSalt + ") on element of IdentificationMessage.sessionOptionalSalt.");
         }
      }
      
      private function _failedAttemptstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._failedAttemptstree.addChild(this._failedAttemptsFunc);
            _loc3_++;
         }
      }
      
      private function _failedAttemptsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhShort();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of failedAttempts.");
         }
         this.failedAttempts.push(_loc2_);
      }
   }
}
