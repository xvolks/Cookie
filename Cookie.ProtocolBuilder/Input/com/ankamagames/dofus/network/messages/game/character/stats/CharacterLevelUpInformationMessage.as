package com.ankamagames.dofus.network.messages.game.character.stats
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class CharacterLevelUpInformationMessage extends CharacterLevelUpMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6076;
       
      
      private var _isInitialized:Boolean = false;
      
      public var name:String = "";
      
      public var id:Number = 0;
      
      public function CharacterLevelUpInformationMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6076;
      }
      
      public function initCharacterLevelUpInformationMessage(param1:uint = 0, param2:String = "", param3:Number = 0) : CharacterLevelUpInformationMessage
      {
         super.initCharacterLevelUpMessage(param1);
         this.name = param2;
         this.id = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.name = "";
         this.id = 0;
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
         this.serializeAs_CharacterLevelUpInformationMessage(param1);
      }
      
      public function serializeAs_CharacterLevelUpInformationMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_CharacterLevelUpMessage(param1);
         param1.writeUTF(this.name);
         if(this.id < 0 || this.id > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.id + ") on element id.");
         }
         param1.writeVarLong(this.id);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CharacterLevelUpInformationMessage(param1);
      }
      
      public function deserializeAs_CharacterLevelUpInformationMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._nameFunc(param1);
         this._idFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CharacterLevelUpInformationMessage(param1);
      }
      
      public function deserializeAsyncAs_CharacterLevelUpInformationMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._nameFunc);
         param1.addChild(this._idFunc);
      }
      
      private function _nameFunc(param1:ICustomDataInput) : void
      {
         this.name = param1.readUTF();
      }
      
      private function _idFunc(param1:ICustomDataInput) : void
      {
         this.id = param1.readVarUhLong();
         if(this.id < 0 || this.id > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.id + ") on element of CharacterLevelUpInformationMessage.id.");
         }
      }
   }
}
