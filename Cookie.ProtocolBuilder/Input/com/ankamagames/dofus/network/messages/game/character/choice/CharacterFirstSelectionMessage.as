package com.ankamagames.dofus.network.messages.game.character.choice
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class CharacterFirstSelectionMessage extends CharacterSelectionMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6084;
       
      
      private var _isInitialized:Boolean = false;
      
      public var doTutorial:Boolean = false;
      
      public function CharacterFirstSelectionMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6084;
      }
      
      public function initCharacterFirstSelectionMessage(param1:Number = 0, param2:Boolean = false) : CharacterFirstSelectionMessage
      {
         super.initCharacterSelectionMessage(param1);
         this.doTutorial = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.doTutorial = false;
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
         this.serializeAs_CharacterFirstSelectionMessage(param1);
      }
      
      public function serializeAs_CharacterFirstSelectionMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_CharacterSelectionMessage(param1);
         param1.writeBoolean(this.doTutorial);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CharacterFirstSelectionMessage(param1);
      }
      
      public function deserializeAs_CharacterFirstSelectionMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._doTutorialFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CharacterFirstSelectionMessage(param1);
      }
      
      public function deserializeAsyncAs_CharacterFirstSelectionMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._doTutorialFunc);
      }
      
      private function _doTutorialFunc(param1:ICustomDataInput) : void
      {
         this.doTutorial = param1.readBoolean();
      }
   }
}
