package com.ankamagames.dofus.network.messages.game.character.creation
{
   import com.ankamagames.dofus.network.enums.PlayableBreedEnum;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class CharacterCreationRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 160;
       
      
      private var _isInitialized:Boolean = false;
      
      public var name:String = "";
      
      public var breed:int = 0;
      
      public var sex:Boolean = false;
      
      public var colors:Vector.<int>;
      
      public var cosmeticId:uint = 0;
      
      private var _colorstree:FuncTree;
      
      private var _colorsindex:uint = 0;
      
      public function CharacterCreationRequestMessage()
      {
         this.colors = new Vector.<int>(5,true);
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 160;
      }
      
      public function initCharacterCreationRequestMessage(param1:String = "", param2:int = 0, param3:Boolean = false, param4:Vector.<int> = null, param5:uint = 0) : CharacterCreationRequestMessage
      {
         this.name = param1;
         this.breed = param2;
         this.sex = param3;
         this.colors = param4;
         this.cosmeticId = param5;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.name = "";
         this.breed = 0;
         this.sex = false;
         this.colors = new Vector.<int>(5,true);
         this.cosmeticId = 0;
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
         this.serializeAs_CharacterCreationRequestMessage(param1);
      }
      
      public function serializeAs_CharacterCreationRequestMessage(param1:ICustomDataOutput) : void
      {
         param1.writeUTF(this.name);
         param1.writeByte(this.breed);
         param1.writeBoolean(this.sex);
         var _loc2_:uint = 0;
         while(_loc2_ < 5)
         {
            param1.writeInt(this.colors[_loc2_]);
            _loc2_++;
         }
         if(this.cosmeticId < 0)
         {
            throw new Error("Forbidden value (" + this.cosmeticId + ") on element cosmeticId.");
         }
         param1.writeVarShort(this.cosmeticId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CharacterCreationRequestMessage(param1);
      }
      
      public function deserializeAs_CharacterCreationRequestMessage(param1:ICustomDataInput) : void
      {
         this._nameFunc(param1);
         this._breedFunc(param1);
         this._sexFunc(param1);
         var _loc2_:uint = 0;
         while(_loc2_ < 5)
         {
            this.colors[_loc2_] = param1.readInt();
            _loc2_++;
         }
         this._cosmeticIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CharacterCreationRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_CharacterCreationRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._nameFunc);
         param1.addChild(this._breedFunc);
         param1.addChild(this._sexFunc);
         this._colorstree = param1.addChild(this._colorstreeFunc);
         param1.addChild(this._cosmeticIdFunc);
      }
      
      private function _nameFunc(param1:ICustomDataInput) : void
      {
         this.name = param1.readUTF();
      }
      
      private function _breedFunc(param1:ICustomDataInput) : void
      {
         this.breed = param1.readByte();
         if(this.breed < PlayableBreedEnum.Feca || this.breed > PlayableBreedEnum.Ouginak)
         {
            throw new Error("Forbidden value (" + this.breed + ") on element of CharacterCreationRequestMessage.breed.");
         }
      }
      
      private function _sexFunc(param1:ICustomDataInput) : void
      {
         this.sex = param1.readBoolean();
      }
      
      private function _colorstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = 0;
         while(_loc2_ < 5)
         {
            this._colorstree.addChild(this._colorsFunc);
            _loc2_++;
         }
      }
      
      private function _colorsFunc(param1:ICustomDataInput) : void
      {
         this.colors[this._colorsindex] = param1.readInt();
         this._colorsindex++;
      }
      
      private function _cosmeticIdFunc(param1:ICustomDataInput) : void
      {
         this.cosmeticId = param1.readVarUhShort();
         if(this.cosmeticId < 0)
         {
            throw new Error("Forbidden value (" + this.cosmeticId + ") on element of CharacterCreationRequestMessage.cosmeticId.");
         }
      }
   }
}
